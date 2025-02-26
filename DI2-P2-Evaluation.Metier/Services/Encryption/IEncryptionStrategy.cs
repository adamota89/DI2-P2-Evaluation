using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI2_P2_Evaluation.Metier.Services.Encryption
{
    public interface IEncryptionStrategy
    {
        string Encrypt(string data, string encryptionKey);
    }
}
