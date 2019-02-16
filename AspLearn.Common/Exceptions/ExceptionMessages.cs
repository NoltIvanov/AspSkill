namespace AspLearn.Common.Exceptions {
    public sealed class ExceptionMessages {
        public static string BuildIntRouteConstraintMessage(string routeParameterName) {
            return string.Format($"Parameter '{routeParameterName}' should be integer");
        }

        public static string BuildGuidRouteConstraintMessage(string routeParameterName) {
            return string.Format($"Parameter '{routeParameterName}' should be guid");
        }

        public static string BuildLongRouteConstraintMessage(string routeParameterName) {
            return string.Format($"Parameter '{routeParameterName}' should be long");
        }
    }
}
