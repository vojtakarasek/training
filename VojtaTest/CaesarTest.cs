using Xunit;
using Vojta;

namespace VojtaTest
{
    public class CaesarTest
    {
        [Theory]
        [InlineData("Ahoj Fiku, kupuj Umtitiho!", "ahojfikukupujumtitiho")]
        void PreparesData(string input, string output)
        {
            var caesar = new Caesar();
            Assert.Equal(output, caesar.PrepareData(input));
        }

        [Theory]
        [InlineData("abc", 3, "DEF")]
        [InlineData("xyz", 3, "ABC")]
        [InlineData("ahojfikukupujumtitiho", 3, "DKRMILNXNXSXMXPWLWLKR")]
        void Encodes(string plain, int key, string cipher)
        {
            var caesar = new Caesar();
            var encrypted = caesar.Encode(caesar.PrepareData(plain), key);
            Assert.Equal(cipher, encrypted);
        }

        [Theory]
        [InlineData("ABC", 3, "xyz")]
        [InlineData("DKRMILNXNXSXMXPWLWLKR", 3, "ahojfikukupujumtitiho")]
        void Decodes(string cipher, int key, string plain)
        {
            var caesar = new Caesar();
            Assert.Equal(plain, caesar.Decode(cipher, key));
        }



       [Fact]
       void CanDecode()
        {
            const string message = "HWVEJAOOPDAMQWHEPUPDWPIWGAOUKQCKPKCNAWPABBKNPPKNAZQYAKRANWHHAJANCUATLAJZEPQNAEPIWGAOUKQSNEPAHWXKNOWREJCLNKCNWIOPDWPKPDANLAKLHASEHHBEJZQOABQHWJZZKYQIAJPSDWPUKQSNKPAOKUKQZKJPDWRAPKWJOSANOKIWJUMQAOPEKJOWXKQPEP";
            var caesar = new Caesar();
            Assert.Equal(22, caesar.FindKey(message, new EnglishFrequency()));
        }

    }
}
