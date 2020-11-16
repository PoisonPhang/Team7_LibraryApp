using System;

namespace DataAccess
{
   public interface IDataRowReader
   {
      bool Read();
      byte GetByte(string name);
      DateTime GetDateTime(string name);
        long GetBigInt(string name);
      int GetInt32(string name);

      double GetDouble(string name);
        float GetFloat(String name);
      string GetString(string name);
      T GetValue<T>(string name);
   }
}