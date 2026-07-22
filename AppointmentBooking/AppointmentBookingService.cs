public class AppointmentBookingService
{
    // Modified to return bool so existing tests that expect a bool compile and run.
    public bool BookAppointment(AppointmentRequest request)
    {
        if (request == null)
            return false;
        if (request.Doctor == null)
            return false;
        if (!request.Doctor.HasAvailableSlot())
        {
            return false;
        }
        request.Doctor.ReserveSlot();
        return true;
    }

    // Optional: keep the old BookingResult-producing API if other code needs it.
    public BookingResult BookAppointmentWithResult(AppointmentRequest request)
    {
        if (request == null)
            return new BookingResult(false, "Appointment request is missing.");
        if (!request.Doctor.HasAvailableSlot())
        {
            return new BookingResult(
                false,
                $"Appointment cannot be booked because {request.Doctor.FullName} has no available slots.");
        }
        request.Doctor.ReserveSlot();
        return new BookingResult(
            true,
            $"Appointment booked successfully for {request.Patient.DisplayName} with {request.Doctor.FullName}.");
    }
}