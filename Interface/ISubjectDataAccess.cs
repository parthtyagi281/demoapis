using DemoApi.Model;

namespace DemoApi.Interface
{
    public interface ISubjectDataAccess
    {
        Task<FunctionResponse> getSubjectRecord();
        Task<FunctionResponse> getSubjectDetailsByID(int subjectID);

    }

}
