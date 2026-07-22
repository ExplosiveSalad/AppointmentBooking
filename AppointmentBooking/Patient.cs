using System;

public class Patient
{
    private string _id;
    private string _legalName;
    private string _preferredName;

    // Parameterless constructor to support object-initializer usage in tests
    public Patient() { }

    public string Id
    {
        get => _id;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Patient ID is required.");
            _id = value;
        }
    }

    // Keep existing LegalName backing but provide FullName to match tests
    public string LegalName
    {
        get => _legalName;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Legal name is required.");
            _legalName = value;
        }
    }

    // Tests use `FullName` property in object-initializers
    public string FullName
    {
        get => LegalName;
        set => LegalName = value;
    }

    public string PreferredName
    {
        get => _preferredName;
        set => _preferredName = value ?? string.Empty;
    }

    public string DisplayName
    {
        get
        {
            if (string.IsNullOrWhiteSpace(PreferredName))
                return LegalName;
            return PreferredName;
        }
    }

    public Patient(string id, string legalName, string preferredName = "")
    {
        Id = id;
        LegalName = legalName;
        PreferredName = preferredName;
    }
}