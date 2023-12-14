using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.TestUtilities;
using Xunit;

namespace LicenseKeyController.Tests;

public class KeyRequestFunctionTests
{
    public KeyRequestFunctionTests()
    {
    }

    [Fact]
    public void TestGetMethod()
    {
        var context = new TestLambdaContext();
        var functions = new KeyRequestFunctions();

        var response = functions.Get(context);

        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

        var serializationOptions = new HttpResultSerializationOptions { Format = HttpResultSerializationOptions.ProtocolFormat.RestApi };
        var apiGatewayResponse = new StreamReader(response.Serialize(serializationOptions)).ReadToEnd();
        Assert.Contains("Hello AWS Serverless", apiGatewayResponse);
    }
}
