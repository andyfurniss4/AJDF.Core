using DAL.Base;
using DAL.DynamoDB.Repositories;
using Ninject;
using System;

namespace DAL.DynamoDb.Console
{
    public class Program
    {
        public static IKernel Kernel;

        public static void Main(string[] args)
        {
            Kernel = new StandardKernel();

            Kernel.Bind<IRepositoryBase<>>().To<DynamoDbRepositoryBase>();

        }
    }
}
