using OldCare.Contexts.SharedContext.Entities;

namespace OldCare.Contexts.ResidentContext.Entities;

public class Bedroom : Entity
{
    #region Public Constructors

    public Bedroom()
    {
    }
    public Bedroom(int capacity, bool gender,
        int number, List<Resident?> residents)
    {
        Capacity = capacity;
        Gender = gender;
        Number = number;
        Residents = residents;
    }

    #endregion

    #region Public Properties

    public int Capacity { get; set; }
    public bool Gender { get; set; }
    public int Number { get; set; }
    public List<Resident?> Residents { get; set; }

    #endregion

    #region Public Methods

    public void ChangeBedroom(int capacity, bool gender, int number)
    {
        Capacity = capacity;
        Gender = gender;
        Number = number;        
    }

    #endregion

}

