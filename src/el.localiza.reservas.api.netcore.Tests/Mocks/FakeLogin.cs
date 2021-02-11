using el.localiza.reservas.api.netcore.Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace el.localiza.reservas.api.netcore.Tests.Mocks
{
    public class FakeLogin : IEnumerable<object[]>
    {
        public static IEnumerable<object[]> GetLoginOKDataGenerator()
        {
            yield return new object[]
            {
                new LoginModel {Usuario = "04183710677", Senha="password123" },
                new LoginModel {Usuario = "131313", Senha="password123" }
            };
        }     

        public IEnumerator<object[]> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
