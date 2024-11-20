using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IRepositories
{
    public interface IReservationRepository
    {
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> CreateReservation(Reservation reservation);
        Task<IEnumerable<Reservation>> GetAllReservation();
        Task<Reservation> UpdateReservation(Reservation reservation);
        Task DeleteReservation(int id);
        Task UpdateReservationStatus(Reservation reservation);

    }
}
