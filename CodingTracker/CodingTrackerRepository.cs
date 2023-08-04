namespace CodingTracker; 
internal class CodingTrackerRepository {
    private readonly CodingTrackerContext _context;

     internal CodingTrackerRepository(CodingTrackerContext context) {
        _context = context;
    }
    public void AddCodingTime(CodingTracker codingTracker) {
        
        
        _context.Add(codingTracker);
        _context.SaveChanges();
    }
   
    public void DeleteCodingTime(CodingTracker codingTracker) {
        _context.Remove(codingTracker);
        _context.SaveChanges();
    }
    public CodingTracker GetCodingTimeById(int codingTimeId) {
        var codingTime = _context.CodingTrackers.FirstOrDefault(ct => ct.Id == codingTimeId);
        if (codingTime != null) {
            return codingTime;
        }
        else {
            return null;
        }
    }
    public List<CodingTracker> GetAllCodingTimes() { 
        using var db = new CodingTrackerContext();
        var AllCodingTimes = db.CodingTrackers.ToList();
        return AllCodingTimes;
    }

    internal void UpdateCodingTime(CodingTracker codingTracker, CodingTracker updatedCodingTracker1) {

        codingTracker.StartTime = updatedCodingTracker1.StartTime;
        codingTracker.EndTime = updatedCodingTracker1.EndTime;
        codingTracker.codingHours = updatedCodingTracker1.codingHours;
        codingTracker.codingMinutes = updatedCodingTracker1.codingMinutes;
        codingTracker.codingSeconds = updatedCodingTracker1.codingSeconds;


        
        
        _context.SaveChanges();
    }
}
