try
{
    if (!Authen.Certification(Session["UserClass"].ToString(), Authen.UserClass.Teacher))
    {
        return RedirectToAction("PermitionEr", "Error");

    }

    return View(db.Category.ToList());
}
catch
{
    return RedirectToAction("LoginEr", "Error");
}