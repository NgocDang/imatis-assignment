import create from 'zustand';
import { API_URL } from '../config/config';
import { calculateFinalPrice } from '../helpers/PriceHelper';
import { Customer, StateType } from './AppType';

const useStore = create<StateType>((set: Function, get: Function) => ({
  customers: [],
  packages: [],
  selectedCustomer: {} as Customer,
  selectedPackages: [],
  finalPrice: 0,
  isLoading: false,
  setLoading: (isLoading: boolean) => set({ isLoading }),
  queryCustomers: async () => {
    const response = await fetch(`${API_URL}/Customer`);
    const customers = (await response.json()) as Array<Customer>;
    set({ customers });
  },
  queryPackages: async () => {
    const response = await fetch(`${API_URL}/Package`);
    set({ packages: await response.json() });
  },
  selectCustomer: (customerId: number = 1) =>
    set((state: StateType) => ({
      selectedCustomer: state.customers.find((x) => x.id === customerId),
    })),
  addToSelectedPackages: (
    packageId: number,
    price: number,
    amount: number = 1
  ) =>
    set((state: StateType) => ({
      selectedPackages: [
        ...state.selectedPackages,
        {
          packageId,
          amount,
          price,
        },
      ],
    })),
  removeFromSelectedPackages: (packageId: number) =>
    set((state: StateType) => ({
      selectedPackages: state.selectedPackages.filter(
        (x) => x.packageId !== packageId
      ),
    })),
  updateSelectedPackageAmount: (packageId: number, amount: number) =>
    set((state: StateType) => ({
      selectedPackages: state.selectedPackages.map((item) => {
        if (item.packageId === packageId) {
          return {
            ...item,
            amount: amount,
          };
        } else {
          return item;
        }
      }),
    })),
  calculateWholeCart: () => {
    set((state: StateType) => ({
      finalPrice: calculateFinalPrice(
        state.selectedCustomer.promotions,
        state.selectedPackages
      ),
    }));
  },
}));

export default useStore;
