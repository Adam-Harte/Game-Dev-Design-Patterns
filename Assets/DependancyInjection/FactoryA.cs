public class FactoryA {
    ServiceA cachedServiceA;

    public ServiceA CreateServiceA() {
        if (cachedServiceA == null) {
            cachedServiceA = new ServiceA();
        }

        return cachedServiceA;
    }
}
