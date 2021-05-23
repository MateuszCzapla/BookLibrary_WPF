using System;
using BookLibrary.ViewModels.Mediator;
using BookLibrary.ViewModels;

namespace BookLibrary.ViewModels.Mediator
{
    class ConcreteMediator : IMediator
    {
        private QueryBookViewModel queryBookViewModel;
        private ResultViewModel resultViewModel;

        public ConcreteMediator(QueryBookViewModel queryBookViewModel, ResultViewModel resultViewModel)
        {
            this.queryBookViewModel = queryBookViewModel;
            this.queryBookViewModel.SetMediator(this);
            this.resultViewModel = resultViewModel;
            this.resultViewModel.SetMediator(this);
        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                //this.resultViewModel.DoC();
            }
            if (ev == "D")
            {
                Console.WriteLine("Mediator reacts on D and triggers following operations:");
                //this.queryBookViewModel.DoB();
                //this.resultViewModel.DoC();
            }
        }
    }
}
