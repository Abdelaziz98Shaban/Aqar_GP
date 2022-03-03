import { Stack } from "@chakra-ui/react";
import NavLink from "./NavLink";

const DesktopNav = ({ items }) => {
  return (
    <Stack
      spacing={4}
      display={{ base: "none", md: "flex" }}
      direction={["row"]}
    >
      {items.map(({ path, content }) => (
        <NavLink key={content} herf={path}>
          {content}
        </NavLink>
      ))}
    </Stack>
  );
};
export default DesktopNav;
