using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Reactive.Bindings.Extensions;

namespace ConsoleApp1;

public class EstacaoReativa : IDisposable
{
    private readonly CompositeDisposable _disposables = [];
    private Subject<int> _temperaturaSubject;
    private Subject<double> _pressaoSubject;

    public EstacaoReativa()
    {
        _temperaturaSubject = new Subject<int>().AddTo(_disposables);
        _pressaoSubject = new Subject<double>().AddTo(_disposables);

        Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe(_ =>
            {
                _temperaturaSubject.OnNext(new Random().Next(30));
            }).AddTo(_disposables);

        Observable.Interval(TimeSpan.FromSeconds(5))
            .Subscribe(_ =>
            {
                _pressaoSubject.OnNext(new Random().Next(100));
            }).AddTo(_disposables);
    }

    public IObservable<int> Temperatura => _temperaturaSubject;
    public IObservable<double> Pressao => _pressaoSubject;

    public void Dispose()
    {
        _disposables.Dispose();
    }
}