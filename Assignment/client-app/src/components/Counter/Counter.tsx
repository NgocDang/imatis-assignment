import { useState } from 'react';
import { Button, FormControl, InputGroup } from 'react-bootstrap';
import useStore from '../../app/store';

type PropType = {
  packageId: number;
  price: number;
};

const Counter = (props: PropType) => {
  const { packageId } = props;
  const [amount, setAmount] = useState(0);
  const {
    addToSelectedPackages,
    removeFromSelectedPackages,
    updateSelectedPackageAmount,
    calculateWholeCart,
  } = useStore((state) => state);

  const handleOnChange = (e: any) => {
    const value =
      e.currentTarget.value === '' ? 0 : parseInt(e.currentTarget.value);

    if (amount === 0 && value > 0) {
      addToSelectedPackages(packageId, props.price, value);
    } else if (amount > 0 && value === 0) {
      removeFromSelectedPackages(packageId);
    } else if (amount === 0 && value === 0) {
      return;
    }

    updateSelectedPackageAmount(packageId, value);
    calculateWholeCart();
    setAmount(value);
  };

  const handleDecrease = () => {
    if (amount - 1 <= 0) {
      removeFromSelectedPackages(packageId);
      setAmount(0);
    } else {
      updateSelectedPackageAmount(packageId, amount - 1);
      setAmount(amount - 1);
    }
    calculateWholeCart();
  };

  const handleIncrease = () => {
    if (amount === 0) {
      addToSelectedPackages(packageId, props.price);
    } else {
      updateSelectedPackageAmount(packageId, amount + 1);
    }

    calculateWholeCart();
    setAmount(amount + 1);
  };

  return (
    <InputGroup className='mb-3'>
      <Button variant='outline-secondary' onClick={handleDecrease}>
        -
      </Button>
      <FormControl
        value={amount}
        onChange={handleOnChange}
        style={{ textAlign: 'center' }}
      />
      <Button variant='outline-secondary' onClick={handleIncrease}>
        +
      </Button>
    </InputGroup>
  );
};

export default Counter;
