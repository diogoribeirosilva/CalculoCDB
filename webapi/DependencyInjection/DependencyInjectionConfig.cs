﻿using CalculoCDB.API.Validators;
using CalculoCDB.Application.Commands;
using CalculoCDB.Application.DTO.DTO;
using CalculoCDB.Application.Handlers;
using CalculoCDB.Application.Queries;
using CalculoCDB.Domain.Interfaces.Repositories;
using CalculoCDB.Infrastruture.Repository.Repositories;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CalculoCDB.API.DependencyInjection
{
    public static class DependencyInjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IInvestimentoRepository, InvestimentoRepository>();
            services.AddScoped<IRequestHandler<CalcularInvestimentoCommand, InvestimentoDto>, CalcularInvestimentoCommandHandler>();
            services.AddScoped<IRequestHandler<ObterInvestimentoQuery, List<InvestimentoDto>>, ObterInvestimentoQueryHandler>();

            // Validators
            services.AddScoped<IValidator<CalcularInvestimentoCommand>, InvestimentoValidator>();

        }
    }
}