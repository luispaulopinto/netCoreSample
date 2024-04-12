// using AutoMapper;
// using Sample.Application.Contracts.Persistence;
// using Sample.Application.Features.Categories.Queries.GetCategoriesList;
// using Sample.Application.Profiles;
// using Sample.Application.UnitTests.Mocks;
// using Sample.Domain.Entities;
// using Moq;
// using Shouldly;

// namespace Sample.Application.UnitTests.Categories.Queries
// {
//     public class GetCategoriesListQueryHandlerTests
//     {
//         private readonly IMapper _mapper;
//         private readonly Mock<IAsyncRepository<Category>> _mockCategoryRepository;

//         public GetCategoriesListQueryHandlerTests()
//         {
//             _mockCategoryRepository = CategoryRepositoryMocks.GetCategoryRepository();
//             var configurationProvider = new MapperConfiguration(cfg =>
//             {
//                 cfg.AddProfile<MappingProfile>();
//             });

//             _mapper = configurationProvider.CreateMapper();
//         }

//         [Fact]
//         public async Task GetCategoriesListTest()
//         {
//             var handler = new GetCategoriesListQueryHandler(_mapper, _mockCategoryRepository.Object);

//             var result = await handler.Handle(new GetCategoriesListQuery(), CancellationToken.None);

//             result.ShouldBeOfType<List<CategoryListVm>>();

//             result.Count.ShouldBe(4);
//         }
//     }
// }


// CREATE PROCEDURE [dbo].[Proc_FileDeliveryConsolidatedData] (@pTransactionDate as date)
//  AS BEGIN
//      -- Busca as informações para popular a tabela ConsolidatedDataAccounts (Accounts)
//      BEGIN TRANSACTION
//      ; WITH w_FileHeader AS
//      (SELECT f.id CDFTransmissionFileId,
//              f.BankId,
//              f.TransmissionHeaderId,
//              f.IssuerEntityId,
//              f.TransmissionTrailerId,
//              f.CreateAt FileCreateFileAt,
//              tm.TransRecordHeaderId,
//              CAST(tm.ProcessingStartDate AS DATE) ProcessingStartDate,
//              CONVERT(VARCHAR, tm.ProcessingStartTime, 108) ProcessingStartTime,
//              CAST(tm.ProcessingEndDate AS DATE) ProcessingEndDate,
//              CONVERT(VARCHAR, tm.ProcessingEndTime, 108) ProcessingEndTime,
//              tm.ProcessorNum,
//              CAST(tr.MasterCardLoadDate AS DATE) MasterCardLoadDate,
//              CAST(tr.MasterCardLoadTime AS TIME) MasterCardLoadTime,
//              i.IssuerNumber,
//              i.ICANumber
//         FROM CDFTransmissionFile f WITH(NOLOCK)
//        INNER JOIN TransmissionHeader tm WITH(NOLOCK)
//           ON tm.id =  f.TransmissionHeaderId
//        INNER JOIN TransRecordHeader tr WITH(NOLOCK)
//           ON tr.id =  tm.TransRecordHeaderId
//        INNER JOIN Issuer i WITH(NOLOCK)
//           ON i.Id = f.IssuerEntityId
//      ),
//      w_Corporate AS

//      (SELECT wfh.*,
//              co.Id CorporateEntityItemId,
//              co.CorporationNumber,
//              co.OrganizationPointEntityId,
//              op.OrganizationPointNumber,
//              pf.PortfolioStatementDate,
//              pf.TotalNumOfAccounts,
//              pf.TotalNumTransactions
//         FROM CorporateEntityItem co WITH(NOLOCK)
//        INNER JOIN w_fileHeader wfh WITH(NOLOCK)
//           ON co.IssuerEntityId = wfh.IssuerEntityId
//         LEFT OUTER JOIN OrganizationPoint op WITH(NOLOCK)
//           ON co.OrganizationPointEntityId = op.Id
//         LEFT OUTER JOIN Portfolio pf WITH(NOLOCK)
//           ON op.PortfolioEntityId = pf.Id
//      ),
//      w_Account AS

//      (SELECT wc.*,
//              ac.Id AccountEntityItemId,
//              ac.AccountNumber,
//              ai.ReportsTo,
//              ai.CorporateProduct,
//              ai.AcceptanceBrandIdCode,
//              ai.ExpirationDate,
//              ai.NameLocaleCode,
//              ai.NameLine1,
//              ac1.AlternateAccountNumber AlternateAccountNumber1,
//              ac2.AlternateAccountNumber AlternateAccountNumber2,
//              CAST(SUBSTRING(cl.Text, 0, LEN(cl.Text)-(CAST(cl.Exponent AS INT)-1))+'.'+SUBSTRING(cl.Text, LEN(cl.Text)-(CAST(cl.Exponent AS INT)-1), CAST(cl.Exponent AS INT)) AS FLOAT) CreditLimit,
//              CAST(SUBSTRING(aoc.text , 0, LEN(aoc.text)-(CAST(aoc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(aoc.text , LEN(aoc.text)-(CAST(aoc.CurrencyExponent AS INT)-1), CAST(aoc.CurrencyExponent AS INT)) AS FLOAT) AdjustmentAmountInOriginalCurrency,

//              aoc.CurrencySign AdjustmentAmountInOriginalCurrency_CurrencySign,
//              CAST(SUBSTRING(apc.text , 0, LEN(apc.text)-(CAST(apc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(apc.text , LEN(apc.text)-(CAST(apc.CurrencyExponent AS INT)-1), CAST(apc.CurrencyExponent AS INT)) AS FLOAT) AdjustmentAmountInPostedCurrency,

//              apc.CurrencySign AdjustmentAmountInPostedCurrency_CurrencySign,
//              CAST(SUBSTRING(abc.text , 0, LEN(abc.text)-(CAST(abc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(abc.text , LEN(abc.text)-(CAST(abc.CurrencyExponent AS INT)-1), CAST(abc.CurrencyExponent AS INT)) AS FLOAT) AdjustmentAmountInBillingCurrency,

//              abc.CurrencySign AdjustmentAmountInBillingCurrency_CurrencySign,
//              GETDATE() CreateAt,
//              NULL UpdateAt,
//              NULL DeleteAt,
//              1 IsActive
//         FROM AccountEntityItem ac WITH(NOLOCK)
//        INNER JOIN w_Corporate wc WITH(NOLOCK)
//           ON ac.CorporateEntityItemEntityId = wc.CorporateEntityItemId
//         LEFT OUTER JOIN AccountInformation ai WITH(NOLOCK)
//           ON ac.AccountInformationId = ai.Id
//         LEFT OUTER JOIN Alternateaccount ac1 WITH(NOLOCK)
//           ON ai.AlternateaccountEntityId =  ac1.Id
//         LEFT OUTER JOIN Alternateaccount ac2 WITH(NOLOCK)
//           ON ai.AlternateaccountEntityId =  ac2.Id
//         LEFT OUTER JOIN CreditLimit cl WITH(NOLOCK)
//           ON ai.CreditLimitEntityId = cl.Id
//         LEFT OUTER JOIN AuthorizationLimits al WITH(NOLOCK)
//           ON ac.AuthorizationLimitsEntityId = al.Id
//         LEFT OUTER JOIN Financialadjustmentrecord far WITH(NOLOCK)
//           ON ac.FinancialadjustmentrecordEntityid = far.Id
//         LEFT OUTER JOIN AmountInOriginalCurrency aoc WITH(NOLOCK)
//           ON far.AmountInOriginalCurrencyEntityId = aoc.Id
//         LEFT OUTER JOIN AmountInPostedCurrency apc WITH(NOLOCK)
//           ON far.AmountInPostedCurrencyEntityId = apc.Id
//         LEFT OUTER JOIN AmountInBillingCurrency abc WITH(NOLOCK)
//           ON far.AmountInBillingCurrencyEntityId = abc.Id
//      )

//          -- Insere na tabela ConsolidatedDataAccounts
//          INSERT INTO ConsolidatedDataAccounts
//          SELECT *
//            FROM w_Account wc WITH(NOLOCK)
//           WHERE wc.CDFTransmissionFileId NOT IN (SELECT cda.CDFTransmissionFileId
//                                                    FROM ConsolidatedDataAccounts cda WITH(NOLOCK)
//                                                   WHERE cda.CDFTransmissionFileId = wc.CDFTransmissionFileId)
//           ORDER BY wc.CDFTransmissionFileId

//      IF @@ERROR = 0
//          COMMIT
//      ELSE
//          ROLLBACK

//      -- Busca as informações para popular a tabela ConsolidatedDataTransactions (Transactions)
//      BEGIN TRANSACTION
//      DECLARE @BinaryHash VARBINARY(MAX);
//  ;WITH w_Transaction AS
//      (SELECT fti.Id FinancialTransactionsEntityItemId,
//              fti.AccountEntityItemEntityId,
//              SUBSTRING(DATENAME(WEEKDAY,ftr.BillingDate), 1,1)+''+REPLACE(ac.AccountNumber+CONVERT(CHAR(8),ftr.BillingDate,112), '********', REPLACE(trim(CONVERT(CHAR(10),ftr.BillingDate,05))+RIGHT(REPLICATE('0',2) + CONVERT(VARCHAR,DAY(ftr.BillingDate)),
// 2), '-', RIGHT(REPLICATE('0',1) + CONVERT(VARCHAR,YEAR(ftr.BillingDate)),1))) TransactionHash,
//              fti.LodgingSummariesAddendumEntityId,
//              fti.PassengerTransportItemEntityId,
//              fti.CardAcceptorId,
//              fti.FinancialTransactionsId,
//              ftr.CustomIdentifier,
//              ftr.DebitOrCreditIndicator,
//              ftr.AcquirerReferenceData,
//              ftr.ProcessorTransactionId,
//              ftr.MasterCardFinancialTransactionId,
//              CAST(ftr.PostingDate as date) PostingDate,
//              CAST(ftr.TransactionDate as date) TransactionDate,
//              CAST(ftr.BillingDate as date) BillingDate,
//              CAST(ftr.ProcessingDate as date) ProcessingDate,
//              ftr.ApprovalCode,
//              CAST(SUBSTRING(aoc.text , 0, LEN(aoc.text)-(CAST(aoc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(aoc.text , LEN(aoc.text)-(CAST(aoc.CurrencyExponent AS INT)-1), CAST(aoc.CurrencyExponent AS INT)) AS FLOAT) AmountInOriginalCurrency,
//              aoc.CurrencySign AmountInOriginalCurrency_CurrencySign,
//              CAST(SUBSTRING(apc.text , 0, LEN(apc.text)-(CAST(apc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(apc.text , LEN(apc.text)-(CAST(apc.CurrencyExponent AS INT)-1), CAST(apc.CurrencyExponent AS INT)) AS FLOAT) AmountInPostedCurrency,
//              apc.CurrencySign AmountInPostedCurrency_CurrencySign,
//              CAST(SUBSTRING(abc.text , 0, LEN(abc.text)-(CAST(abc.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(abc.text , LEN(abc.text)-(CAST(abc.CurrencyExponent AS INT)-1), CAST(abc.CurrencyExponent AS INT)) AS FLOAT) AmountInBillingCurrency,
//              abc.CurrencySign AmountInBillingCurrency_CurrencySign,
//              crp.CardAcceptorName,
//              crp.CardAcceptorCity,
//              crp.CardAcceptorCountryCode,
//              CAST(lss.ArrivalDate as date) ArrivalDate,
//              CAST(lss.DepartureDate as date) DepartureDate,
//              TRIM(lss.GuestName) GuestName,
//              lss.FolioNum,
//              ots.OtherServicesCode,
//              CAST(SUBSTRING(trx.text , 0, LEN(trx.text )-(CAST(trx.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(trx.text , LEN(trx.text)-(CAST(trx.CurrencyExponent AS INT)-1), CAST(trx.CurrencyExponent AS INT)) AS FLOAT) TotalRoomTax,
//              trx.CurrencySign TotalRoomTax_CurrencySign,
//              CAST(SUBSTRING(tta.text , 0, LEN(tta.text )-(CAST(tta.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(tta.text , LEN(tta.text)-(CAST(tta.CurrencyExponent AS INT)-1), CAST(tta.CurrencyExponent AS INT)) AS FLOAT) TotalTaxAmount,
//              tta.CurrencySign TotalTaxAmount_CurrencySign,
//              CAST(SUBSTRING(tfa.text , 0, LEN(tfa.text )-(CAST(tfa.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(tfa.text , LEN(tfa.text)-(CAST(tfa.CurrencyExponent AS INT)-1), CAST(tfa.CurrencyExponent AS INT)) AS FLOAT) TotalFare,
//              tfa.CurrencySign TotalFare_CurrencySign,
//              CAST(SUBSTRING(tfs.text , 0, LEN(tfs.text )-(CAST(tfs.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(tfs.text , LEN(tfs.text)-(CAST(tfs.CurrencyExponent AS INT)-1), CAST(tfs.CurrencyExponent AS INT)) AS FLOAT) TotalFees,
//              tfs.CurrencySign TotalFees_CurrencySign,
//              CAST(SUBSTRING(rra.text , 0, LEN(rra.text )-(CAST(rra.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(rra.text , LEN(rra.text)-(CAST(rra.CurrencyExponent AS INT)-1), CAST(rra.CurrencyExponent AS INT)) AS FLOAT) RoomRateAmount,
//              rra.CurrencySign RoomRateAmount_CurrencySign,
//              CAST(SUBSTRING(tca.Text, 0, LEN(tca.Text)-(CAST(tca.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(tca.Text, LEN(tca.Text)-(CAST(tca.CurrencyExponent AS INT)-1), CAST(tca.CurrencyExponent AS INT)) AS FLOAT) TotalChargesAmount,
//              tca.CurrencySign TotalChargesAmount_CurrencySign,
//              CAST(SUBSTRING(ota.Text, 0, LEN(ota.Text)-(CAST(ota.CurrencyExponent AS INT)-1))+'.'+ SUBSTRING(ota.Text, LEN(ota.Text)-(CAST(ota.CurrencyExponent AS INT)-1), CAST(ota.CurrencyExponent AS INT)) AS FLOAT) OtherServicesAmount,
//              ota.CurrencySign OtherServicesAmount_CurrencySign,
//              dbo.GetReservationFieldData(ftr.HashVcn, ftr.HashVcnV2, 'ID VCN BEE2PAY') VcnId,
//              dbo.GetReservationFieldData(ftr.HashVcn, ftr.HashVcnV2, 'RESERVA OMNIBEES') HotelReservationLocator,
//              GETDATE() CreateAt,
//              NULL UpdateAt,
//              NULL DeleteAt,
//              1 IsActive
//         FROM FinancialTransactionsEntityItem fti WITH(NOLOCK)
//        INNER JOIN AccountEntityItem ac WITH(NOLOCK)
//           ON fti.AccountEntityItemEntityId = ac.Id
//        INNER JOIN FinancialTransactions ftr WITH(NOLOCK)
//           ON fti.FinancialTransactionsId = ftr.Id
//        INNER JOIN AmountInOriginalCurrency aoc WITH(NOLOCK)
//           ON ftr.AmountInOriginalCurrencyEntityId = aoc.Id
//        INNER JOIN AmountInPostedCurrency apc WITH(NOLOCK)
//           ON ftr.AmountInPostedCurrencyEntityId = apc.Id
//         LEFT OUTER JOIN AmountInBillingCurrency abc WITH(NOLOCK)
//           ON ftr.AmountInBillingCurrencyEntityId = abc.Id
//        INNER JOIN CardAcceptor crp WITH(NOLOCK)
//           ON fti.CardAcceptorId = crp.Id
//         LEFT OUTER JOIN LodgingSummariesAddendum lsi WITH(NOLOCK)
//           ON fti.LodgingSummariesAddendumEntityId = lsi.Id
//         LEFT OUTER JOIN LodgingSummaryAddendums lss WITH(NOLOCK)
//           ON lsi.LodgingSummaryAddendumsEntityId = lss.Id
//         LEFT OUTER JOIN TotalRoomTax trx WITH(NOLOCK)
//           ON lss.TotalRoomTaxEntityId = trx.Id
//         LEFT OUTER JOIN TotalTaxAmount tta WITH(NOLOCK)
//           ON lss.TotalTaxAmountEntityId = tta.Id
//         LEFT OUTER JOIN TotalFare tfa WITH(NOLOCK)
//           ON lss.TotalFareEntityId = tfa.Id
//         LEFT OUTER JOIN TotalFees tfs WITH(NOLOCK)
//           ON lss.TotalFeesEntityId = tfs.Id
//         LEFT OUTER JOIN RoomRateAmount rra WITH(NOLOCK)
//           ON lss.RoomRateAmountEntityId = rra.Id
//         LEFT OUTER JOIN TotalChargesAmount tca WITH(NOLOCK)
//           ON lss.TotalChargesAmountEntityId = tca.Id
//         LEFT OUTER JOIN OtherService ots WITH(NOLOCK)
//           ON lss.OtherServiceEntityId = ots.Id
//         LEFT OUTER JOIN OtherServicesAmount ota WITH(NOLOCK)
//           ON ots.OtherServicesAmountEntityId = ota.Id
//        WHERE ftr.CustomIdentifier IS NOT NULL
//      )

//      -- Insere na tabela ConsolidatedDataTransactions
//      INSERT INTO ConsolidatedDataTransactions
//      SELECT *
//        FROM w_Transaction wt WITH(NOLOCK)
//       WHERE CAST(wt.TransactionDate AS DATE) <= @pTransactionDate
//         AND wt.FinancialTransactionsEntityItemId NOT IN (SELECT cdt.FinancialTransactionsEntityItemId
//                                                            FROM ConsolidatedDataTransactions cdt WITH(NOLOCK)
//                                                           WHERE cdt.FinancialTransactionsEntityItemId = wt.FinancialTransactionsEntityItemId)
//                                                           ORDER BY wt.FinancialTransactionsEntityItemId
//      IF @@ERROR = 0
//          COMMIT
//      ELSE
//          ROLLBACK

//  END
