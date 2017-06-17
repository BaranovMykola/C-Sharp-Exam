using Patterns.Field;

namespace Patterns.Builder
{
    class Director
    {
        public IBuilder Builder { get; set; }

        public Director(IBuilder builder)
        {
            Builder = builder;
        }

        public IField Random() => Builder.Random();
    }
}