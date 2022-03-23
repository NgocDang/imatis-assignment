type SelectedPackage = {
  packageId: number;
  amount: number;
  price: number;
};

type Promotion = {
  id: number;
  packageId: number;
  description: string;
  promotionType: number;
  buyingXQuantity: number | null;
  payingYQuantity: number | null;
  discountedPrice: number | null;
};

type Customer = {
  id: number;
  name: string;
  promotions: Array<Promotion>;
};

type Package = {
  id: number;
  description: string;
  name: string;
  price: number;
};

type StateType = {
  customers: Array<Customer>;
  packages: Array<Package>;
  selectedCustomer: Customer;
  selectedPackages: Array<SelectedPackage>;
  finalPrice: number;
  isLoading: boolean;
  setLoading: (isLoading: boolean) => void;
  queryPackages: () => Promise<void>;
  queryCustomers: () => Promise<void>;
  selectCustomer: (customerId?: number) => void;
  addToSelectedPackages: (
    packageId: number,
    price: number,
    amount?: number
  ) => void;
  removeFromSelectedPackages: (packageId: number) => void;
  updateSelectedPackageAmount: (packageId: number, amount: number) => void;
  calculateWholeCart: () => void;
};

export type { SelectedPackage, Customer, Package, Promotion, StateType };
