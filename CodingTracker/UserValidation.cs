using System.ComponentModel.Design;

namespace CodingTracker; 
public class UserValidation {
    public int ParseId() {
        string userCodingTimeId = Console.ReadLine();
        int userCodingTimeIdInt;
        while (!int.TryParse(userCodingTimeId, out userCodingTimeIdInt)) {
            Console.WriteLine("\n\n Invalid input. Please input the id in integer format.");
            userCodingTimeId = Console.ReadLine();
        }
        return userCodingTimeIdInt;
    }
    public bool IdExists(CodingTracker codingTracker) {


        if (codingTracker == null) {
            Console.WriteLine("Invalid input please try again.");
            return false;
        }

        else return true;
    }
}
