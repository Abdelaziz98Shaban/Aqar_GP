import NavLink from "./NavLink";
import { Stack, Button, Text, Flex } from "@chakra-ui/react";
import { MoonIcon, SunIcon } from "@chakra-ui/icons";

const MobileNav = ({ items, colorMode, toggleColorMode }) => {
  return (
    <Stack spacing={4} pb={4} display={{ md: "none" }} direction={["column"]}>
      <Flex
        h='1rem'
        px={2}
        py={1}
        alignItems='center'
        justifyContent={"space-between"}
      >
        <Text>Dark Mood:</Text>
        <Button onClick={toggleColorMode}>
          {colorMode === "light" ? <MoonIcon /> : <SunIcon />}
        </Button>
      </Flex>

      {items.map(({ path, content }) => (
        <NavLink key={content} herf={path}>
          {content}
        </NavLink>
      ))}
    </Stack>
  );
};
export default MobileNav;
