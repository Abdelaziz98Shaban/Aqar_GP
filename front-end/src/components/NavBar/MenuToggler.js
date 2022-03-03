import { IconButton } from "@chakra-ui/react";
import { CloseIcon, HamburgerIcon } from "@chakra-ui/icons";

const MenuToggler = ({ isOpen, onClose, onOpen }) => {
  return (
    <IconButton
      size={"md"}
      icon={isOpen ? <CloseIcon /> : <HamburgerIcon />}
      aria-label={"Open Menu"}
      display={{ base: "flex", md: "none" }}
      onClick={isOpen ? onClose : onOpen}
    />
  );
};
export default MenuToggler;
