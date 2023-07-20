using AutoMapper;
using Moq;
using registroClientes.Application.Dtos;
using registroClientes.Application.Services;
using registroClientes.Domain.Interfaces;
using registroClientes.Domain.Model;
using Xunit;

namespace registroClientes.Tests;

public class RegistroClientesControllerTestes
{
    public class RegistroServiceTests
    {
        private readonly RegistroService _registroService;
        private readonly Mock<IRegistroRepository> _registroRepositoryMock;
        private readonly IMapper _mapper;

        public RegistroServiceTests()
        {
            // Configuração do mapeamento
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Telefone, TelefoneDto>().ReverseMap();
                cfg.CreateMap<Cliente, ClienteDto>()
                    .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones));
                cfg.CreateMap<ClienteDto, Cliente>()
                    .ForMember(dest => dest.Telefones, opt => opt.MapFrom(src => src.Telefones));
            });
            _mapper = mapperConfig.CreateMapper();

            // Configuração do mock do repositório
            _registroRepositoryMock = new Mock<IRegistroRepository>();

            // Inicialização do serviço com o mock do repositório e o mapeador
            _registroService = new RegistroService(_registroRepositoryMock.Object, _mapper);
        }

        [Fact]
        public async Task BuscarTodosClientes_ShouldReturnAllClientes()
        {
            // Arrange
            var clientes = new List<Cliente>
            {
                new Cliente { Id = 1, NomeCompleto = "João", Email = "joao@example.com" },
                new Cliente { Id = 2, NomeCompleto = "Maria", Email = "maria@example.com" }
            };
            _registroRepositoryMock.Setup(repo => repo.BuscarTodosClientesAsync()).ReturnsAsync(clientes);

            // Act
            var result = await _registroService.BuscarTodosClientes();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, ((List<Cliente>)result).Count);
        }

        [Fact]
        public async Task AtualizarNumeroContato_ShouldCallAtualizarNumeroContatoAsync()
        {
            // Arrange
            var cliente = new Cliente
            {
                Id = 1,
                NomeCompleto = "João da Silva",
                Email = "joao@example.com",
                Telefones = new List<Telefone>
                {
                        new Telefone { Id = 1, DDD_Numero = "123456789",   Tipo = "celular" },
                        new Telefone { Id = 2, DDD_Numero = "123456788", Tipo = "fixo" }
                }
            };
            var clienteDto = new ClienteDto
            {
                Id = 1,
                NomeCompleto = "João da Silva",
                Email = "joao@example.com",
                Telefones = new List<TelefoneDto>
                {
                        new TelefoneDto { Id = 1, DDD_Numero = "123456789",   Tipo = "celular" },
                        new TelefoneDto{ Id = 2, DDD_Numero = "123456788", Tipo = "fixo" }
                }
            };

            // Act
            await _registroService.AtualizarNumeroContato(clienteDto);

            // Assert
            _registroRepositoryMock.Verify(repo => repo.AtualizarNumeroContatoAsync(It.IsAny<Cliente>()), Times.Once);
        }


        [Fact]
        public async Task BuscarPorNumeroContato_ShouldReturnClienteByNumeroContato()
        {
            // Arrange
            var numeroContato = "123456789";
            var cliente = new Cliente
            {
                Id = 1,
                NomeCompleto = "João da Silva",
                Email = "joao@example.com",
                Telefones = new List<Telefone>
                {
                        new Telefone { Id = 1, DDD_Numero = "123456789",   Tipo = "celular" },
                        new Telefone { Id = 2, DDD_Numero = "123456788", Tipo = "fixo" }
                }
            };

            _registroRepositoryMock.Setup(repo => repo.BuscarPorNumeroContatoAsync(numeroContato)).ReturnsAsync(cliente);

            // Act
            var result = await _registroService.BuscarPorNumeroContato(numeroContato);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(numeroContato, result.Telefones.First().DDD_Numero);
        }

        [Fact]
        public async Task CadastrarCliente_ShouldCallCadastrarClienteAsync()
        {
            var clienteDto = new ClienteDto
            {
                Id = 1,
                NomeCompleto = "João da Silva",
                Email = "joao@example.com",
                Telefones = new List<TelefoneDto>
                {
                        new TelefoneDto { Id = 1, DDD_Numero = "123456789",   Tipo = "celular" },
                        new TelefoneDto { Id = 2, DDD_Numero = "123456788", Tipo = "fixo" }
                }
            };
            // Arrange
            var clienteModel = _mapper.Map<Cliente>(clienteDto);

            // Act
            await _registroService.CadastrarCliente(clienteDto);

            // Assert
            _registroRepositoryMock.Verify(repo => repo.CadastrarClienteAsync(It.IsAny<Cliente>()), Times.Once);
        }

        [Fact]
        public async Task AtualizarEmail_ShouldCallAtualizarEmailAsync()
        {
            // Arrange
            var clienteDto = new ClienteDto { NomeCompleto = "Fulano", Email = "fulano@example.com" };
            var clienteModel = _mapper.Map<Cliente>(clienteDto);

            // Act
            await _registroService.AtualizarEmail(clienteDto);

            // Assert
            _registroRepositoryMock.Verify(repo => repo.AtualizarEmailAsync(It.IsAny<Cliente>()), Times.Once);
        }

        [Fact]
        public async Task DeletarPorEmail_ShouldReturnTrueWhenRepositoryReturnsTrue()
        {
            // Arrange
            string email = "fulano@example.com";
            _registroRepositoryMock.Setup(repo => repo.DeletarPorEmailAsync(email)).ReturnsAsync(true);

            // Act
            bool result = await _registroService.DeletarPorEmail(email);

            // Assert
            Assert.True(result);
        }
    }
}