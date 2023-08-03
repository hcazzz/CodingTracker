namespace CodingTracker; 
internal class CodingTrackerRepository {
    private readonly CodingTrackerContext _context;

    public CodingTrackerRepository(CodingTrackerContext context) {
        _context = context;
    }
    public void AddCodingTime(CodingTracker codingTracker) {
        using var db = new CodingTrackerContext();
        
        db.Add(codingTracker);
        db.SaveChanges();
    }
    public void UpdateCodingTime() {
        //_context.Update()

    }
    public void DeleteCodingTime() {

    }
    public void GetCodingTime() {

    }
    public List<CodingTracker> GetAllCodingTimes() { 
        using var db = new CodingTrackerContext();
        var AllCodingTimes = db.CodingTrackers.ToList();
        return AllCodingTimes;
    }

}
