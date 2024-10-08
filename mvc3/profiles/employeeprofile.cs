


using AutoMapper;
using Data_access_lyer.models;
using mvc3.viewmodels;
namespace mvc3.profiles
{
    public class employeeprofile :Profile
    {
        public employeeprofile()
        {
            CreateMap<employee, employeeprofile>().ReverseMap();
        }
    }
}
