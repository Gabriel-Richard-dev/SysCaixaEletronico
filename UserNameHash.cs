using System.Text;

namespace SysCaixaeletronico;

public class UserNameHash
{
    public StringBuilder _hash = new StringBuilder();

    public void AdicionaHash(string usrName)
    {
        _hash.Append(usrName);
    }
}