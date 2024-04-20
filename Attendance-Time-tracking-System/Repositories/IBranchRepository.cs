namespace Attendance_Time_tracking_System.Repositories;

public interface IBranchRepository
{


    List<Branch> GetAll();


    /// <summary>
    /// gets tracks available in a branch in a specific intake
    /// </summary>
    /// <param name="branchId">Branch Id</param>
    /// <param name="intakeId">intake Id</param>
    /// <returns>returns the available tracks in a branch in a specific intake</returns>
    IEnumerable<Track> GetTracksInBranch(int branchId, int? intakeId = null);


    /// <summary>
    /// Gets stundets of an intake track in a specific branch. 
    /// </summary>
    /// <param name="branchId">Id of branch</param>
    /// <param name="intakeId">Id of intake</param>
    /// <param name="trackId">Id of track</param>
    /// <returns>returns a collection of track students in a specific intake in a branch or all students in this branch if the trackId is null</returns>
    IEnumerable<Student> GetBranchStundents(int branchId ,int intakeId ,int? trackId = null);



}