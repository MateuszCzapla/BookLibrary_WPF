using System;

namespace BookLibrary.ViewModels.Mediator
{
    public class ConcreteMediator : IMediator
    {
        private ResultViewModel resultViewModel;
        private QueryBookViewModel queryBookViewModel;

        public ConcreteMediator(ResultViewModel resultViewModel, QueryBookViewModel queryBookViewModel)
        {
            this.queryBookViewModel = queryBookViewModel;
            this.queryBookViewModel.SetMediator(this);
            this.resultViewModel = resultViewModel;
            this.resultViewModel.SetMediator(this);
        }

        public ConcreteMediator()
        {

        }

        public void Notify(object sender, string ev)
        {
            if (ev == "A")
            {
                Console.WriteLine("Mediator reacts on A and triggers folowing operations:");
                //this.resultViewModel.DoC();
            }
            if (ev == "B")
            {
                Console.WriteLine("Mediator reacts on B and triggers following operations:");
                //this.queryBookViewModel.DoB();
                this.resultViewModel.TestResultVM();
            }
        }
    }
}
