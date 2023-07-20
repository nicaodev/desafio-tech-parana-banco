using AutoFixture;
using AutoMapper;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using registroClientes.API.Controllers;
using registroClientes.Application.Dtos;
using registroClientes.Application.Services;
using registroClientes.Domain.Interfaces;
using registroClientes.Domain.Model;
using registroClientes.Infra.Data.Context;
using System.Numerics;
using Xunit;


namespace registroClientes.Domain.Tests.TestesXUnit;

public class RegistroClientesControllerTestes 
{
    [Fact]
    public void Testando()
    {
        var addCliente = new Fixture().Create<ClienteDto>();

        var clienteRepositoryMock = new Mock<IRegistroRepository>();

        var clienteMapperMock = new Mock<IMapper>();

        var clienteService = new RegistroService(clienteRepositoryMock.Object, clienteMapperMock.Object);


        // ACT

        var resultado = clienteService.BuscarTodosClientes();

        // Assert

        var okObjectResult = Assert.IsType<OkObjectResult>(resultado);
        Assert.Equal(200, okObjectResult.StatusCode);

        var customers = Assert.IsType<List<ClienteDto>>(okObjectResult.Value);
        Assert.Equal(2, customers.Count);
    }
   
}