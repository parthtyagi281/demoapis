using DemoApi.Model;

namespace DemoApi.Interface
{
    public interface IStudentDataAccess
    {
        Task<FunctionResponse> getStudentRecord();
        Task<FunctionResponse> getStudentDetailsByID(int StudentID);
        Task<FunctionResponse> addStudent(StudentModel studentModel);
    }
}
