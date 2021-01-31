package com.example.siins_android.Fragment;

import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import androidx.fragment.app.Fragment;

import com.example.siins_android.Acitivty.DetailsActivity;
import com.example.siins_android.Model.HomeworkList;
import com.example.siins_android.Model.ListAdapter;
import com.example.siins_android.R;
import com.example.siins_android.Model.SampleData;

import org.json.JSONException;

import java.net.MalformedURLException;
import java.text.ParseException;

public class ListFragment extends Fragment {
    ListView listView;

    public ListFragment() {
        // Required empty public constructor
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.list, container, false);

        listView = (ListView) v.findViewById(R.id.listViewfrag);
        try {
            if(HomeworkList.GetList().size() == 0) {
                HomeworkList.InitializeHomeworkData(getActivity());
            }
            final ListAdapter c = new ListAdapter(getActivity(), HomeworkList.GetList());
            listView.setAdapter(c);
        } catch (MalformedURLException e) {
            e.printStackTrace();
        } catch (JSONException e) {
            e.printStackTrace();
        } catch (ParseException e) {
            e.printStackTrace();
        }



        listView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView parent, View v, int position, long id) {
                SampleData item = (SampleData) parent.getItemAtPosition(position);
                Intent intent = new Intent(getActivity(), DetailsActivity.class);
                intent.putExtra("detail",item);
                startActivity(intent);
            }
        });

        return v;
    }
}
