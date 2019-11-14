using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using NewsAgregator.API.Helpers;

namespace NewsAgregator.API.Profiles
{
    public class UsersProfile: Profile
    {
        public UsersProfile()
        {
            CreateMap<Entities.User, Models.UserDto>()
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(SRC => $"{SRC.FirstName} {SRC.LastName}"))
                .ForMember(
                dest => dest.Age,
                opt => opt.MapFrom(src => src.DateOfBirth.GetCurrectAge()));

            CreateMap<Models.UserForCreationDto, Entities.User>()
                .ForMember(
                dest => dest.Password,
                opt => opt.MapFrom(src => HashPassword(src.Password)));
        }


        public string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            //Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            //Console.WriteLine($"Hashed: {hashed}");
            return hashed;
        }
    }
}
