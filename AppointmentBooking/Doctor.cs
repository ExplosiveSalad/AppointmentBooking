using System;

public class Doctor
{
    private string _id;
    private string _fullName;
    private int _availableSlots;

    // Parameterless constructor to support object-initializer usage in tests
    public Doctor() { }

    public string Id
    {
        get => _id;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Doctor ID is required.");
            _id = value;
        }
    }

    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Doctor name is required.");
            _fullName = value;
        }
    }

    public int AvailableSlots
    {
        get => _availableSlots;
        set
        {
            if (value < 0)
                throw new ArgumentException("Available slots cannot be negative.");
            _availableSlots = value;
        }
    }

    public Doctor(string id, string fullName, int availableSlots)
    {
        Id = id;
        FullName = fullName;
        AvailableSlots = availableSlots;
    }

    public bool HasAvailableSlot()
    {
        return AvailableSlots > 0;
    }

    public void ReserveSlot()
    {
        if (!HasAvailableSlot())
            throw new InvalidOperationException("No appointment slots are available.");
        AvailableSlots--;
    }
}