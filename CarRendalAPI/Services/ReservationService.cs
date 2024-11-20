using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;
using CarRentalAPI.Models;

namespace CarRendalAPI.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;

        }

        // Create a reservation
        public async Task<ReservationResDTO> CreateReservation(ReservationReqDTO reservationReqDTO)
        {
            var reservation = new Reservation
            {
                ReservationDate = reservationReqDTO.ReservationDate,
                EndDate = reservationReqDTO.EndDate,
                Status = reservationReqDTO.Status,
                CarId = reservationReqDTO.CarId,
                UserId = reservationReqDTO.UserId
            };

            await _reservationRepository.CreateReservation(reservation);

            var reservationResDTO = new ReservationResDTO
            {
                ReservationId = reservation.ReservationId,
                ReservationDate = reservation.ReservationDate,
                EndDate = reservation.EndDate,
                Status = reservation.Status,
                CarId = reservation.CarId,
                UserId = reservation.UserId
            };

            return reservationResDTO;

        }

        // Get a reservation by ID
        public async Task<Reservation> GetReservationById(int id)
        {
            var data = await _reservationRepository.GetReservationById(id);
            return data;
        }

        // Get all reservations
        public async Task<IEnumerable<Reservation>> GetAllReservation()
        {
            return await _reservationRepository.GetAllReservation();
        }

        // Update a reservation by ID
        public async Task<ReservationResDTO> UpdateReservation(int id, ReservationReqDTO reservationReqDTO)
        {

            var existingreservation = await _reservationRepository.GetReservationById(id);
            if (existingreservation == null)
            {
                throw new KeyNotFoundException("Reservation not found.");
            }

            existingreservation.ReservationDate = reservationReqDTO.ReservationDate;
            existingreservation.EndDate = reservationReqDTO.EndDate;
            existingreservation.Status = reservationReqDTO.Status;
            existingreservation.CarId = reservationReqDTO.CarId;
            existingreservation.UserId = reservationReqDTO.UserId;

            await _reservationRepository.UpdateReservation(existingreservation);

            var reservationResDTO = new ReservationResDTO
            {
                ReservationId = existingreservation.ReservationId,
                ReservationDate = existingreservation.ReservationDate,
                EndDate = existingreservation.EndDate,
                Status = existingreservation.Status,
                CarId = existingreservation.CarId,
                UserId = existingreservation.UserId,
            };

            return reservationResDTO;
        }

        // Delete a reservation by ID
        public async Task DeleteReservation(int id)
        {
            await _reservationRepository.DeleteReservation(id);
        }

        // Update the status of a reservation
        public async Task<ReservationResDTO> UpdateReservationStatus(int id, UpdateReservationStatusDTO updateReservationStatusDTO)
        {
            // Retrieve the reservation by ID
            var reservation = await _reservationRepository.GetReservationById(id);

            if (reservation == null)
            {
                return null; // Return null or throw an exception if the reservation doesn't exist
            }

            // Update the status
            reservation.Status = updateReservationStatusDTO.Status;

            // Save changes to the database
            await _reservationRepository.UpdateReservationStatus(reservation);

            // Return the updated reservation as a response DTO
            return new ReservationResDTO
            {
                ReservationId = reservation.ReservationId,
                ReservationDate = reservation.ReservationDate,
                EndDate = reservation.EndDate,
                Status = reservation.Status,
                CarId = reservation.CarId,
                //Car = new CarResDTO
                //{
                //    CarId = reservation.Car.CarId,
                //    Make = reservation.Car.Make,
                //    Model = reservation.Car.Model,
                //    LicensePlate = reservation.Car.LicensePlate
                //},
                UserId = reservation.UserId,
                //User = new UserResDTO
                //{
                //    UserId = reservation.User.UserId,
                //    FullName = reservation.User.FullName,
                //    Email = reservation.User.Email
                //}
            };
        }

    }
}

