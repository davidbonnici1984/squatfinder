using System;
using System.Collections.Generic;
using System.Linq;
using DnsTwisterMonitor.Core.Http;
using DnsTwisterMonitor.Core.Models;
using DnsTwisterMonitor.Core.ViewModels;
using DnsTwisterMonitor.Core.Services.Renders;

namespace DnsTwisterMonitor.Core.Services
{
    public class TwisterService
    {
        private readonly IImageRenderService _imageRenderService;

        public TwisterService()
        {
            _imageRenderService = new PageToImageService();
        }

        public MonitorTestResultViewModel GetFuzzyDomains(DomainViewRequest domainViewRequest)
        {
            var client = new TwisterHttpClient();

            var domains = client.GetFuzzyDomains(domainViewRequest.Domain);

            var domainViewComponentList = MapToDomainViewComponent(domains);

            var domainTestResultViewModel = new MonitorTestResultViewModel
            {
                MonitorTestViewList = domainViewComponentList,
                DomainMonitored = domainViewRequest.Domain,
                DomainFuzzerTypesList = null
            };

            var ddd = ((10 / 20) * 100);

            //Group results by fuzzer types
            var results = domainViewComponentList.GroupBy(
                p => p.AlgorithmType, (type, grouped) =>
                new DomainFuzzerType
                {
                    FuzzerType = type,
                    Count = grouped.Count(),
                    Percentage = Convert.ToInt16((Convert.ToDecimal(grouped.Count()) / Convert.ToDecimal(domainViewComponentList.Count())) * 100m)
                }).ToList();

            domainTestResultViewModel.DomainFuzzerTypesList = results;

            return domainTestResultViewModel;
        }

        private List<MonitorTestViewModel> MapToDomainViewComponent(TwisterResponseWrapper wrapper)
        {
            return wrapper.FuzzyDomainList.Select(fuzzyDomain => new MonitorTestViewModel()
            {
                Url = fuzzyDomain.Domain,
                ImageUrl = _imageRenderService.GenerateImageUrl(fuzzyDomain.Domain),
                AlgorithmType = fuzzyDomain.FuzzerType,
                RedirectUrl = $"http://{fuzzyDomain.Domain}"
            })
                .ToList();
        }


    }

    public static class LinqExtentions
    {
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}