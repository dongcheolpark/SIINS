using System;
using testweb2.Models;


namespace testweb2.Func
{
    public static class Authen
    {
        public enum UserClass {Student = 0, Teacher = 1, Admin = 2}; //유저의 권한을 번호로 매김

        public static bool Certification(string userclass,UserClass certiClass) // 유저의 권한, 검증 해야하는 권한
        {
            var userClass = (UserClass)Enum.Parse(typeof(UserClass), userclass);
            try
            {
                if ((int)userClass >= (int)certiClass)//만약 유저의 권한이 접근해야 하는 권한보다 높다면
                {
                    return true;
                }
                else throw (new Exception());
            }
            catch
            {
                return false;
            }
        }
    }
}