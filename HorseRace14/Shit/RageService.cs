using System;
using System.Threading;

namespace HorseRace14.Shit
{
    public static class RageService
    {
        public static void CallRandomMethod()
        {
            var random = new Random();
            var waitTime = random.Next(1, 100);

            Thread.Sleep(waitTime);
        }

        public static void CallLeGrosRPG()
        {
            var headers = ApiClient.CreateParameterCollection("CSP-Session-Pref", "WESessionHttpRedirection=silo4");
            headers.Add("Bearer", "eyJhbGciOiJIUzUxMiJ9.eyJleHAiOjE1NDY2Mzk5MjEsInVuaXF1ZV9uYW1lIjoic3RhZmYiLCJkb21haW4iOiJMSUFET00wMSIsImlzcyI6Imh0dHA6Ly90b2tlbi5pYS5jYSIsImF1ZCI6Imh0dHA6Ly93d3cuaWEuY2EiLCJyb2xlIjoiR3JvdXBJbnN1cmFuY2VTdGFmZk1lbWJlciIsIm5hbWVpZCI6InN0YWZmIiwiY2xpZW50TnVtYmVyIjoiIiwiY29tcGFueUNvZGUiOiIwIn0.V1KQLKHlCx4JkCN3UV-T5dxRHw2viL0h8kJH3ueBTXgKvXMQ0Fxfoh2SZ11MMXfjDwfMJuR_s0_zNfunFjEcmA");

            var apiClient = new ApiClient("http://wa.fnct.webui.ia.iafg.net/webadmin", headers);
            var queryParameters = ApiClient.CreateParameterCollection("contractId", "0000023551-0000000065-00102");

            var response = apiClient.Get<dynamic>("v2/api/member", null, queryParameters);
            return;
        }

        public static void CallFiveLastClaims()
        {
            var headers = ApiClient.CreateParameterCollection("Bearer", "eyJhbGciOiJIUzUxMiJ9.eyJleHAiOjE1NDY2Mzk5MjEsInVuaXF1ZV9uYW1lIjoic3RhZmYiLCJkb21haW4iOiJMSUFET00wMSIsImlzcyI6Imh0dHA6Ly90b2tlbi5pYS5jYSIsImF1ZCI6Imh0dHA6Ly93d3cuaWEuY2EiLCJyb2xlIjoiR3JvdXBJbnN1cmFuY2VTdGFmZk1lbWJlciIsIm5hbWVpZCI6InN0YWZmIiwiY2xpZW50TnVtYmVyIjoiIiwiY29tcGFueUNvZGUiOiIwIn0.V1KQLKHlCx4JkCN3UV-T5dxRHw2viL0h8kJH3ueBTXgKvXMQ0Fxfoh2SZ11MMXfjDwfMJuR_s0_zNfunFjEcmA");

            var apiClient = new ApiClient("http://hc.fnct.webservice.ia.iafg.net:50080/HCMWPN30", headers);

            var queryParameters = new ApiClientParameterCollection();
            queryParameters.Add("from_date", "2015-01-01");
            queryParameters.Add("start_index", "1");
            queryParameters.Add("number_to_fetch", "5");
            queryParameters.Add("include_details", "true");

            var response = apiClient.Get<dynamic>("v2/membercontracts/0000023551-0000000065-00102/claims/search", null, queryParameters);
            return;
        }

        public static void CallProviderSearch()
        {
            var apiClient = new ApiClient("http://hc.fnct.webservice.ia.iafg.net:50080/HCMWPN37");

            var queryParameters = new ApiClientParameterCollection();
            queryParameters.Add("name", "tremblay");
            queryParameters.Add("specialty_id", "12");
            queryParameters.Add("province_code", "QC");

            var response = apiClient.Get<dynamic>("v1/providers", null, queryParameters);
            return;
        }


        public static void CallBenefitSummary()
        {
            var headers = ApiClient.CreateParameterCollection("CSP-Session-Pref", "WESessionHttpRedirection=silo4");
            headers.Add("Bearer", "eyJhbGciOiJIUzUxMiJ9.eyJleHAiOjE1NDY2Mzk5MjEsInVuaXF1ZV9uYW1lIjoic3RhZmYiLCJkb21haW4iOiJMSUFET00wMSIsImlzcyI6Imh0dHA6Ly90b2tlbi5pYS5jYSIsImF1ZCI6Imh0dHA6Ly93d3cuaWEuY2EiLCJyb2xlIjoiR3JvdXBJbnN1cmFuY2VTdGFmZk1lbWJlciIsIm5hbWVpZCI6InN0YWZmIiwiY2xpZW50TnVtYmVyIjoiIiwiY29tcGFueUNvZGUiOiIwIn0.V1KQLKHlCx4JkCN3UV-T5dxRHw2viL0h8kJH3ueBTXgKvXMQ0Fxfoh2SZ11MMXfjDwfMJuR_s0_zNfunFjEcmA");

            var apiClient = new ApiClient("http://wa.fnct.webui.ia.iafg.net/webadmin", headers);

            var response = apiClient.Get<dynamic>("v2/api/benefitSummary?contractId=0000023551-0000000065-00102");
            return;
        }
    }
}
