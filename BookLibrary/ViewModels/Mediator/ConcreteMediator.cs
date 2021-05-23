using System;

namespace BookLibrary.ViewModels.Mediator
{
    class ConcreteMediator : IMediator
    {
        private QueryBookViewModel queryBookViewModel;
        private OldResultViewModel resultViewModel;

        public ConcreteMediator(QueryBookViewModel queryBookViewModel, OldResultViewModel resultViewModel)
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
