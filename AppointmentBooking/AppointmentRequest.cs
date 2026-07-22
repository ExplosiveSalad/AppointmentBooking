public class AppointmentRequest
{
    private Patient _patient;
    private Doctor _doctor;
    private DateTime _requestedDate;

    // Parameterless constructor to support object-initializer usage in tests
    public AppointmentRequest() { }

    public Patient Patient
    {
        get => _patient;
        set => _patient = value ?? throw new ArgumentNullException(nameof(Patient));
    }

    public Doctor Doctor
    {
        get => _doctor;
        set => _doctor = value ?? throw new ArgumentNullException(nameof(Doctor));
    }

    public DateTime RequestedDate
    {
        get => _requestedDate;
        set
        {
            if (value.Date < DateTime.Today)
                throw new ArgumentException("Requested appointment date cannot be in the past.");
            _requestedDate = value;
        }
    }

    public AppointmentRequest(Patient patient, Doctor doctor, DateTime requestedDate)
    {
        Patient = patient;
        Doctor = doctor;
        RequestedDate = requestedDate;
    }
}