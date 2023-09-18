﻿using Microsoft.AspNetCore.Mvc;
using Shop.data;
using Shop.Models.Spaceship;
using ShopCore.Dto;
using ShopCore.ServiceInterface;

namespace Shop.Controllers
{
    public class SpaceshipsController : Controller
    {

        private readonly ShopContext _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController
            (
            ShopContext context,
            ISpaceshipServices spaceshipServices
            )
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
        }

        
        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceShipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    EnginePower = x.EnginePower,
                    Passengers = x.Passengers,
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipsCreateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                EnginePower = vm.EnginePower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight,
            };

            var result = await _spaceshipServices.Create(dto);


            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.GetAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new SpaceshipDetailsViewModel();


            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.Passengers = spaceship.Passengers;
            vm.EnginePower = spaceship.EnginePower;
            vm.Crew = spaceship.Crew;
            vm.Company = spaceship.Company;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
                
            return View(vm);
        }
    }
}
