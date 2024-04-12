using CryptoWallet.Application.Contracts.Persistence;
using CryptoWallet.Application.Services.Option_Transaction.Commands.Queries.GetOptionTransactionList;
using CryptoWallet.Domain.Entities;
using Moq;

namespace CryptoWallet.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Test1()
        {
            //setup
            Mock<IOptionTransactionRepository>? _optionTransactionRepository = new Mock<IOptionTransactionRepository>();
            _optionTransactionRepository.Setup(x => x.GetOptionTransactionListAsync())
            .ReturnsAsync(
                new List<OptionTransaction>() {
                    new OptionTransaction() { Amount = 100, Balance = 10 },
                    new OptionTransaction() { Amount = 11, Balance = 10 },
                    new OptionTransaction() { Amount = 22, Balance = 10 },
                    new OptionTransaction() { Amount = 33, Balance = 10 },
                    new OptionTransaction() { Amount = 44, Balance = 10 },
                });

            //action
            GetOptionTransactionListQueryHandler handler = new GetOptionTransactionListQueryHandler(_optionTransactionRepository.Object);
            var result = await handler.Handle(new GetOptionTransactionListQuery(), new CancellationToken());


 ;
        }
    }
}