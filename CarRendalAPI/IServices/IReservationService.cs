using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.Models;

namespace CarRendalAPI.IServices
{
    public interface IReservationService
    {
        Task<ReservationResDTO> CreateReservation(ReservationReqDTO reservationReqDTO);
        Task<Reservation> GetReservationById(int id);
        Task<IEnumerable<Reservation>> GetAllReservation();
        Task<ReservationResDTO> UpdateReservation(int id, ReservationReqDTO reservationReqDTO);
        Task DeleteReservation(int id);
        Task<ReservationResDTO> UpdateReservationStatus(int id, UpdateReservationStatusDTO updateReservationStatusDTO);
    }
}
