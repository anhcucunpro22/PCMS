namespace PCMS.Interfaces
{
    public interface ICustomerApi
    {
        Task<string> SearchCustomerByName(string name);
    }
}
