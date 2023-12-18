using GameAboutBattlesOfArmies.BL.Contracts;
using GameAboutBattlesOfArmies.BL.Controller;
using GameAboutBattlesOfArmies.BL.Controller.Command;
using GameAboutBattlesOfArmies.BL.Controller.Facade;
using GameAboutBattlesOfArmies.BL.Controlller;
using GameAboutBattlesOfArmies.BL.Strategy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GameAboutBattlesOfArmies.BL.Models.Repository;
using GameAboutBattlesOfArmies.BL.Controller.Decorator.DecoratorBuf;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace GameAboutBattlesOfArmies.Settings
{
    public class Configuration
    {
        public IServiceCollection Service { get; }

        public Configuration()
        {
            Service = new ServiceCollection();
           // Service.add
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            Service.AddSingleton(mapper);
            //  Setup();
        }

        public virtual IServiceProvider Setup()
        {
            Service.AddTransient<ArmieController>();          
            Service.AddSingleton<Fight>();
            Service.AddSingleton<IFightFacade, FightFacade>();
            Service.AddTransient<ITurnStrategy, TurnStrategyVertically>();
            Service.AddTransient<ITurnStrategy, TurnStrategyRows>();
            Service.AddTransient<ITurnStrategy, TurnStrategyHorizontally>();
            Service.AddScoped<ICommand, TurnCommand>();
            Service.AddScoped<ICommand, StrategyCommand>();
            Service.AddScoped<ContextTurn>();            
            Service.AddSingleton<SerialisableArmie>();          
            Service.AddScoped<Invoker>();

            Service.AddTransient<IUnit,UnitRepository>();
            Service.AddTransient<IUnit, BufDecoratorBase>();
            Service.AddTransient<BufDecoratorBase, BufDecorator>();

            return Service.BuildServiceProvider();
            
        }

    }
}