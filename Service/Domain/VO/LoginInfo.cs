using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerManager.Domain.VO
{
    public class LoginInfo : ValueObject
    {
        public string LoginUser { get; private set; }
        public LoginMethod LoginMethod { get; private set; }
        public string Password { get; private set; }
        public string PublicKey { get; private set; }
        public string PublicKeyPassword { get; private set; }

        public LoginInfo(string loginUser, LoginMethod loginMethod, string password, string publicKey, string publicKeyPassword)
        {
            Valid(loginUser, loginMethod, password, publicKey, publicKeyPassword);

            LoginUser = loginUser;
            LoginMethod = loginMethod;
            Password = password;
            PublicKey = publicKey;
            PublicKeyPassword = publicKeyPassword;
        }

        public static void Valid(string loginUser, LoginMethod loginMethod, string password, string publicKey, string publicKeyPassword)
        {
            ValidLoginUser(loginUser);
            ValidLoginMethod(loginMethod);

            if (loginMethod.Method == 1)
                ValidPassword(password);
            else if (loginMethod.Method == 2)
            {
                ValidPublicKey(publicKey);
                ValidPublicKeyPassword(publicKeyPassword);
            }
        }

        public static void ValidLoginUser(string loginUser)
        {
            if (string.IsNullOrWhiteSpace(loginUser)) throw new Exception("用户名无效");
            if (loginUser.Length > 128) throw new Exception("用户名最大128个非空字符");
        }

        public static void ValidLoginMethod(LoginMethod loginMethod)
        {
            if (loginMethod == null) throw new Exception("登陆方式无效");
        }

        public static void ValidPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password)) throw new Exception("密码无效");
            if (password.Length > 128) throw new Exception("密码最大128个非空字符");
        }

        public static void ValidPublicKey(string publicKey)
        {
            if (string.IsNullOrWhiteSpace(publicKey)) throw new Exception("密钥无效");
            //if (publicKey.Length > 128) throw new Exception("密码最大128个非空字符");
        }

        public static void ValidPublicKeyPassword(string publicKeyPassword)
        {
            if (!string.IsNullOrWhiteSpace(publicKeyPassword)
                && publicKeyPassword.Length > 128) throw new Exception("密码最大128个非空字符");
        }

    }
}
