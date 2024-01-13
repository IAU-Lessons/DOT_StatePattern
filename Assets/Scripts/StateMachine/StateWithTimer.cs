using UnityEngine;

namespace StateMachine
{
    public abstract class StateWithTimer : BaseState
    {
        protected float countTime;
        protected float elapsedTime;
        private bool isStarted = false;
        
        public StateWithTimer(float countTime)
        {
            this.countTime = countTime;
        }

        public override void UpdateState(BaseStateMachine machine)
        {
            if(!isStarted) return;
            elapsedTime += Time.deltaTime;
            if (this.elapsedTime >= this.countTime)
            {
                isStarted = false;
                CountDownFinished(machine);
            }
        }

        public override void LeaveState(BaseStateMachine machine)
        {
            elapsedTime = 0;
        }

        protected abstract void CountDownFinished(BaseStateMachine machine);

        protected void StartTimer()
        {
            isStarted = true;
        }
        
    }
}