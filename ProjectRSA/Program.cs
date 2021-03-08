using ProjectRSA.RSA;

namespace ProjectRSA
{
    class Program
    {
        static void Main(string[] args)
        {
            var rsa = new RsaHandler();
            rsa.CalculateRsa();
            
        }
    }
}
