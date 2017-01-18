using System.Threading.Tasks;

namespace SparkPost
{
    public interface ISubaccounts
    {
        Task<ListSubaccountResponse> List();

        Task<CreateSubaccountResponse> Create(SubaccountCreate subaccount);

        Task<UpdateSubaccountResponse> Update(SubaccountUpdate subaccount);
    }
}