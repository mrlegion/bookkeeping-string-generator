using DAL.Repository.Implimentation;
using DAL.Repository.Interface;
using GalaSoft.MvvmLight.Ioc;

namespace DAL
{
    public class DalBootstrapper
    {
        public static void Init()
        {
            SimpleIoc.Default.Register<IBankRepository, BankRepository>();
        }
    }
}