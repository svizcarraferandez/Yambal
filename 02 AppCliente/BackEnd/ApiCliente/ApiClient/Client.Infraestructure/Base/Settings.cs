using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Client.Infraestructure.Base
{
    [Serializable]
    public class Settings
    {
        private string sConnectionString;
        public string ConnectionString
        {
            get
            {
              // return sConnectionString = "Data Source = 192.168.144.31\\sqlexpress2016; Initial Catalog = DB_SGM; User ID = sa; Password = 12desarrolloA";
              return sConnectionString = "Data Source = localhost; Initial Catalog = Cliente; User ID = ADMIN; Password = ADMIN";
              //  return sConnectionString = "Data Source = waywa; Initial Catalog = db_pcm_gob_pe_mancomunidades; User ID = usr_pcm_mancomunidades; Password = Usr_pcm_Mina765SGM";

            }
            set
            {
                sConnectionString = value;
            }
        }

        public void Save()
        {
            Save("./Settings.avl");
            return;
        }

        public void Save(string Path)
        {
            byte[] bKey = { 4, 4, 7, 2, 0, 3, 6, 5 };
            byte[] bVector = { 0, 9, 6, 7, 0, 3, 8, 2 };
            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();
            try
            {
                using (FileStream fileStream = new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateEncryptor(bKey, bVector), CryptoStreamMode.Write))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(cryptoStream, this);
                    }
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo guardar el archivo de configuración: " + Path + "\r\nEl error devuelto fue: " + eXception.Message, eXception);
            }
        }

        public void Load()
        {
            //Load("./Settings.avl");
            //ConnectionString = "Data Source=192.168.144.31; Initial Catalog=db_pcm_gob_pe_claim; User ID=usr_pcm_gob_pe_claim; Password=usr_pcm_gob_pe_claim";
            //return;
        }

        public void Load(string Path)
        {
            byte[] bKey = { 4, 4, 7, 2, 0, 3, 6, 5 };
            byte[] bVector = { 0, 9, 6, 7, 0, 3, 8, 2 };
            DESCryptoServiceProvider desCryptoServiceProvider = new DESCryptoServiceProvider();
            try
            {
                using (FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, desCryptoServiceProvider.CreateDecryptor(bKey, bVector), CryptoStreamMode.Read))
                    {
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        ConnectionString = ((Settings)binaryFormatter.Deserialize(cryptoStream)).ConnectionString;
                    }
                }
            }
            catch (Exception eXception)
            {
                throw new Exception("No se pudo leer el archivo de configuración: " + Path + "\r\nEl error devuelto fue: " + eXception.Message, eXception);
            }
        }
    }
}
