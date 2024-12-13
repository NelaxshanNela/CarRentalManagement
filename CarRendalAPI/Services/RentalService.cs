using CarRendalAPI.DTOs.RequestDTOs;
using CarRendalAPI.DTOs.ResponceDTOs;
using CarRendalAPI.DTOs.ResponseDTOs;
using CarRendalAPI.IRepositories;
using CarRendalAPI.IServices;
using CarRendalAPI.Models;
using CarRendalAPI.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRendalAPI.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        // Create a new rental
        public async Task<RentalResDTO> CreateRental(RentalReqDTO rentalReqDTO)
        {
            var rental = new Rental
            {
                RentalStartDate = rentalReqDTO.RentalStartDate,
                RentalEndDate = rentalReqDTO.RentalEndDate,
                TotalAmount = rentalReqDTO.TotalAmount,
                RentalStatus = rentalReqDTO.RentalStatus,
                CarId = rentalReqDTO.CarId,
                UserId = rentalReqDTO.UserId
            };

            await _rentalRepository.CreateRental(rental);

            var rentalResDTO = new RentalResDTO
            {
                RentalId = rental.RentalId,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                TotalAmount = rental.TotalAmount,
                RentalStatus = rental.RentalStatus,
                CarId = rental.CarId,
                UserId = rental.UserId
            };

            return rentalResDTO;
        }

        // Get all rentals
        public async Task<IEnumerable<RentalResDTO>> GetAllRentals()
        {
            var rentals = await _rentalRepository.GetAllRentals();
            return rentals.Select(rental => new RentalResDTO
            {
                RentalId = rental.RentalId,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                TotalAmount = rental.TotalAmount,
                RentalStatus = rental.RentalStatus,
                CarId = rental.CarId,
                CarName = rental.Car.Model?.Name, // Assuming Car has a Name property
                UserId = rental.UserId,
                UserName = rental.User?.FirstName, // Assuming User has a Name property
                CreatedAt = rental.CreatedAt,
                Payments = rental.Payments?.Select(payment => new PaymentResDTO
                {
                    PaymentId = payment.PaymentId,
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    PaymentStatus = payment.PaymentStatus,
                    PaymentMethod = payment.PaymentMethod
                }).ToList()
            });
        }

        // Get a rental by ID
        public async Task<RentalResDTO> GetRentalById(int id)
        {
            var rental = await _rentalRepository.GetRentalById(id);

            if (rental == null)
                throw new KeyNotFoundException($"Rental with ID {id} not found");

            return new RentalResDTO
            {
                RentalId = rental.RentalId,
                RentalStartDate = rental.RentalStartDate,
                RentalEndDate = rental.RentalEndDate,
                TotalAmount = rental.TotalAmount,
                RentalStatus = rental.RentalStatus,
                CarId = rental.CarId,
                CarName = rental.Car.Model?.Name, // Assuming Car has a Name property
                UserId = rental.UserId,
                UserName = rental.User?.FirstName, // Assuming User has a Name property
                CreatedAt = rental.CreatedAt,
                Payments = rental.Payments?.Select(payment => new PaymentResDTO
                {
                    PaymentId = payment.PaymentId,
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate,
                    PaymentStatus = payment.PaymentStatus,
                    PaymentMethod = payment.PaymentMethod
                }).ToList()
            };
        }

        // Update an existing rental
        public async Task<RentalResDTO> UpdateRental(int id, RentalReqDTO rentalReqDTO)
        {
            var existingRental = await _rentalRepository.GetRentalById(id);

            if (existingRental == null)
                throw new KeyNotFoundException($"Rental with ID {id} not found");

            existingRental.RentalStartDate = rentalReqDTO.RentalStartDate;
            existingRental.RentalEndDate = rentalReqDTO.RentalEndDate;
            existingRental.TotalAmount = rentalReqDTO.TotalAmount;
            existingRental.RentalStatus = rentalReqDTO.RentalStatus;
            existingRental.CarId = rentalReqDTO.CarId;
            existingRental.UserId = rentalReqDTO.UserId;

            await _rentalRepository.UpdateRental(existingRental);

            return new RentalResDTO
            {
                RentalId = existingRental.RentalId,
                RentalStartDate = existingRental.RentalStartDate,
                RentalEndDate = existingRental.RentalEndDate,
                TotalAmount = existingRental.TotalAmount,
                RentalStatus = existingRental.RentalStatus,
                CarId = existingRental.CarId,
                CarName = existingRental.Car.Model?.Name, // Assuming Car has a Name property
                UserId = existingRental.UserId,
                UserName = existingRental.User?.FirstName, // Assuming User has a Name property
                Payments = existingRental.Payments?.Select(payment => new PaymentResDTO
                {
                    PaymentId = payment.PaymentId,
                    Amount = payment.Amount,
                    PaymentDate = payment.PaymentDate
                }).ToList()
            };
        }

        // Delete a rental by ID
        public async Task DeleteRental(int id)
        {
            await _rentalRepository.DeleteRental(id);
        }

        // Get rentals by UserId
        public async Task<IEnumerable<Rental>> GetRentalsByUserId(int userId)
        {
            return await _rentalRepository.GetRentalsByUserId(userId);
        }

        // Get rentals by CarId
        public async Task<IEnumerable<Rental>> GetRentalsByCarId(int carId)
        {
            return await _rentalRepository.GetRentalsByCarId(carId);
        }

        // Get total rentals for a car
        public async Task<int> GetTotalRentalsForCar(int carId)
        {
            return await _rentalRepository.GetTotalRentalsForCar(carId);
        }

        public async Task<string> UpdateRentalStatus(int id, UpdateRentalReqDTO updateRentalReqDTO)
        {
            var rental = await _rentalRepository.GetRentalById(id);

            if (rental == null)
            {
                return null;
            }

            rental.RentalStatus = updateRentalReqDTO.RentalStatus;
            rental.UpdatedAt = DateTime.Now;

            await _rentalRepository.UpdateRentalStatus(rental);

            return "Status Update Successfully";
        }
    }
}
