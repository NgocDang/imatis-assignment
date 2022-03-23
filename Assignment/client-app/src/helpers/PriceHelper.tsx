import { Promotion, SelectedPackage } from '../app/AppType';
import promotionType from '../consts/PromotionType.json';

const calculateForBuyXPayYPromotion = (
  promotion: Promotion,
  selectedPackage: SelectedPackage
) => {
  if (promotion.promotionType !== promotionType.buyXPayY) return 0;

  const { amount } = selectedPackage;
  const { buyingXQuantity, payingYQuantity } = promotion;

  const payingTimes = Math.floor(amount / buyingXQuantity!);
  const leftAmount = amount % buyingXQuantity!;
  const payingQuantity = payingYQuantity! * payingTimes + leftAmount;

  return selectedPackage.price * payingQuantity;
};

const calculateDiscountPromotion = (
  promotion: Promotion,
  selectedPackage: SelectedPackage
) => {
  if (promotion.promotionType !== promotionType.priceDiscount) return 0;

  const { amount } = selectedPackage;
  const { discountedPrice } = promotion;

  return discountedPrice! * amount;
};

const calculateFinalPrice = (
  promotions: Array<Promotion>,
  selectedPackages: Array<SelectedPackage>
) => {
  let finalPrice = 0;

  if (promotions.length === 0)
    selectedPackages.forEach(
      (pkg: SelectedPackage) => (finalPrice += pkg.amount * pkg.price)
    );
  else {
    selectedPackages.forEach((pkg: SelectedPackage) => {
      promotions.forEach((promotion: Promotion) => {
        if (promotion.packageId === pkg.packageId) {
          finalPrice += calculateForBuyXPayYPromotion(promotion, pkg);
          finalPrice += calculateDiscountPromotion(promotion, pkg);
        } else {
          finalPrice += pkg.amount * pkg.price;
        }
      });
    });
  }

  return finalPrice;
};

export {
  calculateDiscountPromotion,
  calculateForBuyXPayYPromotion,
  calculateFinalPrice,
};
