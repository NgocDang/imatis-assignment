import useStore from '../../app/store';

const Summary = () => {
  const finalPrice = useStore((state) => state.finalPrice);

  return <>{`Total: $${finalPrice.toFixed(2)}`}</>;
};

export default Summary;
